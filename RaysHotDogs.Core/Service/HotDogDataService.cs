using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Repository;
using System.Collections.Generic;

namespace RaysHotDogs.Core.Service
{
  public class HotDogDataService
  {
    private static HotDogRepository hotDogRepository = new HotDogRepository();

    public static List<HotDog> GetAllHotDogs() => hotDogRepository.GetAllHotDogs();
    public static List<HotDogGroup> GetGroupedHotDogs() => hotDogRepository.GetGroupedHotDogs();
    public static List<HotDog> GetHotDogsForGroup(int hotDogsGroupId) => hotDogRepository.GetHotDogsForGroup(hotDogsGroupId);
    public static List<HotDog> GetFavoriteHotDogs() => hotDogRepository.GetFavoriteHotDogs();
    public static HotDog GetHotDogById(int hotDogId) => hotDogRepository.GetHotDogById(hotDogId);
  }
}
