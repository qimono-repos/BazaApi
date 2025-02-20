using BazaAPI.Models;
using MongoDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Query
{
    public async Task<List<EmojiModel>> GetEmojis()
    {
        System.Console.WriteLine(nameof(this.GetEmojis));
        return await DB.Find<ImageModel>().ToListAsync();
    }
}
