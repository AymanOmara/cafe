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

        public async Task<ReadOnlyMealDto> AddMeal(WriteOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = await _repository.Create(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }

        public async Task DeleteMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            await _repository.Delete(mealEntity);
        }

        public async Task<ICollection<ReadOnlyMealDto>> GetAllMeals()
        {
            var result = await _repository.GetAllRecords();
            return _mapper.Map<List<ReadOnlyMealDto>>(result);
        }

        public async Task<ReadOnlyMealDto> UpdateMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = await _repository.Update(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }
    }
}

