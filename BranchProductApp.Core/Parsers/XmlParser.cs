using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;
using System.Xml;

namespace BranchProductApp.Core.Parsers;

public static class XmlParser
{
    public static List<Branch> DeserializeBranchXml(string filePath)
    {
        var branches = new List<Branch>();

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        var branchNodes = xmlDoc.SelectNodes("//Branch");

        if (branchNodes != null)
        {
            foreach (XmlNode branchNode in branchNodes)
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

                branches.Add(branch);
            }
        }

        return branches;
    }

    public static List<Product> DeserializeProductXml(string filePath)
    {
        var products = new List<Product>();

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        var productNodes = xmlDoc.SelectNodes("//Product");

        if (productNodes != null)
        {
            foreach (XmlNode productNode in productNodes)
            {

                if (string.IsNullOrWhiteSpace(productNode.Attributes["Name"]?.Value))
                {
                    // Skip this product if Name is missing or empty
                    continue;
                }

                var product = new Product
                {
                    Id = int.Parse(productNode.Attributes["ID"]?.Value ?? "0"),
                    Name = productNode.Attributes["Name"]?.Value,
                    WeightedItem = productNode.Attributes["WeightedItem"]?.Value == "Y",
                    SuggestedSellingPrice = decimal.TryParse(
                        productNode.Attributes["SuggestedSellingPrice"]?.Value,
                        out var price) ? price : null
                };

                products.Add(product);
            }
        }

        return products;
    }

    public static List<ProductBranchMapping> DeserializeMappingsXml(string filePath)
    {
        var mappings = new List<ProductBranchMapping>();

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        var mappingNodes = xmlDoc.SelectNodes("//BranchProduct");

        if (mappingNodes != null)
        {
            foreach (XmlNode mappingNode in mappingNodes)
            {
                var branchIdAttr = mappingNode.Attributes["BranchID"];
                var productIdAttr = mappingNode.Attributes["ProductID"];

                // Skip the node if either BranchID or ProductID is missing
                if (branchIdAttr == null || productIdAttr == null)
                {
                    continue;
                }

                if (int.TryParse(branchIdAttr.Value, out var branchId) &&
                    int.TryParse(productIdAttr.Value, out var productId))
                {

                    var mapping = new ProductBranchMapping
                    {
                        BranchId = branchId,
                        ProductId = productId
                    };

                    mappings.Add(mapping);
                }
            }
        }

        return mappings;
    }
}
