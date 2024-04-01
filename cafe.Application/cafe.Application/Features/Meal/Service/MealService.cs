using AutoMapper;
using cafe.Domain.Meal;
using cafe.Application.Features.Meal.DTO;
using cafe.Domain.Features.Meal.Service;
using cafe.Domain.Common;
using cafe.Common;

namespace cafe.Application.Features.Meal
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly LanguageService _localization;
        public MealService(IUnitOfWork unitOfWork, IMapper mapper, LanguageService localization)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localization = localization;
        }

        public async Task<ReadOnlyMealDto> AddMeal(WriteOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = await _unitOfWork.Meals.Create(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }

        public async Task DeleteMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            await _unitOfWork.Meals.Delete(mealEntity);
        }

        public async Task<ICollection<ReadOnlyMealDto>> GetAllMeals()
        {
            var result = await _unitOfWork.Meals.GetAllRecords();
            return _mapper.Map<List<ReadOnlyMealDto>>(result);
        }

        public async Task<ReadOnlyMealDto> UpdateMeal(UpdateOnlyMealDto dto)
        {
            var mealEntity = _mapper.Map<MealEntity>(dto);
            var result = await _unitOfWork.Meals.Update(mealEntity);
            return _mapper.Map<ReadOnlyMealDto>(result);
        }
    }
}

