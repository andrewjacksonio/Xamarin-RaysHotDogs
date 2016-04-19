using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Repository;
using System.Collections.Generic;

namespace RaysHotDogs.Core.Service
{
  public class HotDogDataService
  {
    private static HotDogRepository hotDogRepository = new HotDogRepository();

    public List<HotDog> GetAllHotDogs() => hotDogRepository.GetAllHotDogs();
    public List<HotDogGroup> GetGroupedHotDogs() => hotDogRepository.GetGroupedHotDogs();
    public List<HotDog> GetHotDogsForGroup(int hotDogsGroupId) => hotDogRepository.GetHotDogsForGroup(hotDogsGroupId);
    public List<HotDog> GetFavoriteHotDogs() => hotDogRepository.GetFavoriteHotDogs();
    public HotDog GetHotDogById(int hotDogId) => hotDogRepository.GetHotDogById(hotDogId);
  }
}
