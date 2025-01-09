using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;
using System.Xml;
using System.Globalization;

namespace BranchProductApp.Core.Parsers;

public static class XmlImporter
{
    private static List<T> DeserializeXml<T>(string filePath, string xPath, Func<XmlNode, T> createEntityFromNode)
    {
        var entities = new List<T>();

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        var nodes = xmlDoc.SelectNodes(xPath);

        if (nodes != null)
        {
            foreach (XmlNode node in nodes)
            {
                var entity = createEntityFromNode(node);
                if (entity != null)
                {
                    entities.Add(entity);
                }
            }
        }

        return entities;
    }

    private static Branch CreateBranchFromNode(XmlNode branchNode)
    {
        var branch = new Branch
        {
            Id = int.Parse(branchNode.Attributes["ID"]?.Value),
            Name = branchNode.Attributes["Name"]?.Value,
            TelephoneNumber = branchNode.Attributes["TelephoneNumber"]?.Value
        };

        var openDateString = branchNode.Attributes["OpenDate"]?.Value;
        if (DateTime.TryParseExact(openDateString, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
        {
            branch.OpenDate = parsedDate;
        }

        return branch;
    }

    private static Product CreateProductFromNode(XmlNode productNode)
    {
        if (string.IsNullOrWhiteSpace(productNode.Attributes["Name"]?.Value))
        {
            return null; // Skip this product if Name is missing or empty
        }

        return new Product
        {
            Id = int.Parse(productNode.Attributes["ID"]?.Value ?? "0"),
            Name = productNode.Attributes["Name"]?.Value,
            WeightedItem = productNode.Attributes["WeightedItem"]?.Value == "Y",
            SuggestedSellingPrice = decimal.TryParse(
                productNode.Attributes["SuggestedSellingPrice"]?.Value,
                CultureInfo.InvariantCulture,
                out var price) ? price : null
        };
    }

    private static ProductBranchMapping CreateMappingFromNode(XmlNode mappingNode)
    {
        var branchIdAttr = mappingNode.Attributes["BranchID"];
        var productIdAttr = mappingNode.Attributes["ProductID"];

        // Skip the node if either BranchID or ProductID is missing
        if (branchIdAttr == null || productIdAttr == null)
        {
            return null;
        }

        if (int.TryParse(branchIdAttr.Value, out var branchId) &&
            int.TryParse(productIdAttr.Value, out var productId))
        {
            return new ProductBranchMapping
            {
                BranchId = branchId,
                ProductId = productId
            };
        }

        return null;
    }

    public static List<Branch> DeserializeBranchXml(string filePath)
    {
        return DeserializeXml(filePath, "//Branch", CreateBranchFromNode);
    }

    public static List<Product> DeserializeProductXml(string filePath)
    {
        return DeserializeXml(filePath, "//Product", CreateProductFromNode);
    }

    public static List<ProductBranchMapping> DeserializeMappingsXml(string filePath)
    {
        return DeserializeXml(filePath, "//BranchProduct", CreateMappingFromNode);
    }
}
