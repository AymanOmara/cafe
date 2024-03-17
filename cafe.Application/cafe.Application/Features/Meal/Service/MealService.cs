using AutoMapper;
using cafe.Application.Features.Meal.Service;
using cafe.Domain.Meal;
using cafe.Domain.Meal.Repository;
using cafe.Application.Features.Meal.DTO;

namespace cafe.Application.Features.Meal
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _repository;
        private readonly IMapper _mapper;
        public MealService(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReadOnlyMealDto AddMeal(WriteOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = _repository.AddMeal(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }

        public void DeleteMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            _repository.DeleteMeal(mealEntity);
        }

        public ICollection<ReadOnlyMealDto> GetAllMeals()
        {
            var result = _repository.GetAllMeals();
            return _mapper.Map<List<ReadOnlyMealDto>>(result);
        }

        public ReadOnlyMealDto UpdateMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = _repository.UpdateMeal(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }
    }
}

