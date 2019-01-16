using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Any File",
        GUID = "16681682-25f4-41be-bca5-fc8421e6c102",
        Description = "Use this to upload any type of file.")]
    public class AnyFile : MediaData
    {
    }
}
