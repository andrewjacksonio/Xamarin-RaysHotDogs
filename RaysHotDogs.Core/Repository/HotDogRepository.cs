using RaysHotDogs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
  public class HotDogRepository
  {
    private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>
    {
      new HotDogGroup
      {
        Id=1,Title="Meat Lovers",ImagePath="",
        HotDogs=
        {
          new HotDog
          {
            Id=1,
            Name="Regular Hot Dog",
            ShortDescription="The best there is on the Planet",
            Description="Manchego smelly cheese danish fontina.",
            ImagePath="hotdog1",
            Available=true,
            PrepTime=10,
            Ingredients=new List<string> {"Regular bun","Sausage","Ketchup" },
            Price=8,
            IsFavorite=true
          },
          new HotDog
          {
            Id=2,
            Name="Haute Dog",
            ShortDescription="The Classy One",
            Description="Bacon ipsum dolor amet",
            ImagePath="hotdog2",
            Available=true,
            PrepTime=15,
            Ingredients=new List<string> {"Baked bun","Gourmet Sausage" },
            Price=10,
            IsFavorite=false
          },
          new HotDog
          {
            Id=3,
            Name="Extra Long",
            ShortDescription="For when a regular one isn't enough",
            Description="Capicola short loin shoulder strip steak ribeye",
            ImagePath="hotdog3",
            Available=true,
            PrepTime=10,
            Ingredients=new List<string> {"Extra Long Bun","Extra Long Sausage" },
            Price=8,
            IsFavorite=true
          }
        }
      },
      new HotDogGroup
      {
        Id=2,Title="Veggie Lovers",ImagePath="",
        HotDogs=new List<HotDog>
        {
          new HotDog
          {
            Id=4,
            Name="Veggie Hot Dog",
            ShortDescription="American for non-meat-lovers",
            Description="Veggies es bonus vorbis, proinde vos postulo",
            ImagePath="hotdog4",
            Available=true,
            PrepTime=10,
            Ingredients=new List<string> { "Bun","Vegetarian Sausage"},
            Price=8,
            IsFavorite=false
          },
          new HotDog
          {
            Id= 5,
            Name="Haute Dog Veggie",
            ShortDescription="Classy and Veggie",
            Description="Turnip greens yarrow ricebean rutabasa",
            ImagePath="hotdog5",
            Available=true,
            PrepTime=15,
            Ingredients = new List<string> { "Baked Bun","Gourmet Veggie Sausage" },
            Price=10,
            IsFavorite=true
          },
          new HotDog
          {
            Id=6,
            Name="Extra Long Veggie",
            ShortDescription="For when a regular one isn't enough",
            Description="Beetroot water spinach okra water chestnut",
            ImagePath="hotdog6",
            Available=true,
            PrepTime=10,
            Ingredients=new List<string> {"Extra Long Bun","Extra Long Veggie Sausage" },
            Price=8,
            IsFavorite=false
          }
        }
      }
    };

    public List<HotDog> GetAllHotDogs()
    {
      return (from hotDogGroups in hotDogGroups
              from hotDog in hotDogGroups.HotDogs
              select hotDog).ToList();
    }

    public HotDog GetHotDogById(int id)
    {
      return (from hotDogGroups in hotDogGroups
              from hotDog in hotDogGroups.HotDogs
              where hotDog.Id == id
              select hotDog).FirstOrDefault();
    }

    public List<HotDogGroup> GetGroupedHotDogs() => hotDogGroups;
    public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
    {
      return (from hotDogGroups in hotDogGroups
              from hotDog in hotDogGroups.HotDogs
              where hotDogGroups.Id == hotDogGroupId
              select hotDog).ToList();
    }
    public List<HotDog> GetFavoriteHotDogs()
    {
      return (from hotDogGroups in hotDogGroups
              from hotDog in hotDogGroups.HotDogs
              where hotDog.IsFavorite
              select hotDog).ToList();
    }
  }
}
