using MongoDB.Entities;

namespace ImageApi.Models;

public class EmojiModel : Entity
{
    public string Url { get; set; }
    public string Name { get; set; }
    public string Unicode { get; set; }
}
