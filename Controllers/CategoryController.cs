using APIRestful.Models.Dto.Category;
using APIRestful.Service.IService;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace APIRestful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private IValidator<CategoryInsertDto> _insertValidator;
        private IValidator<CategoryUpdateDto> _updateValidator;
        private IMapper _mappper;

        public CategoryController(IValidator<CategoryInsertDto> categoryInsertValidator, IValidator<CategoryUpdateDto> categoryUpdateValidator, ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _insertValidator = categoryInsertValidator;
            _updateValidator = categoryUpdateValidator;
            _mappper = mapper;
        }

        [HttpGet("GetCategories")]
        public async Task<IEnumerable<CategoryDto>> GetCategories()
            => await _categoryService.GetCategories();

        [HttpGet("GetCategoryById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategory(id);

            return category != null ? Ok(category) : NotFound();
        }

        [HttpPost("AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryInsertDto insert)
        {
            var validationsResult = await _insertValidator.ValidateAsync(insert);

            if (!validationsResult.IsValid)
            {
                return BadRequest(validationsResult.Errors);
            }

            var valresult = _categoryService.Validate(insert);

            if (!valresult.IsSuccess)
            {
                return BadRequest(valresult.Error.Message);
            }

            var categoryResult = await _categoryService.CreateCategory(insert);

            if (!categoryResult.IsSuccess)
            {
                return BadRequest(categoryResult.Error.Message);
            }

            var category = categoryResult.Value;

            return CreatedAtAction("GetCategoryById", new { id = category.Id }, category);
        }

        [HttpPatch("UpdateCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(CategoryUpdateDto update, int id)
        {
            var validationsResult = await _updateValidator.ValidateAsync(update);

            if (!validationsResult.IsValid)
            {
                return BadRequest(validationsResult.Errors);
            }

            var valresult = _categoryService.Validate(update, id);

            if (!valresult.IsSuccess)
            {
                return BadRequest(valresult.Error.Message);
            }

            var categoryDto = await _categoryService.UpdateCategory(update, id);

            if (!categoryDto.IsSuccess)
            {
                return NotFound(categoryDto);
            }

            return Ok(categoryDto.Value);
        }

        [HttpDelete("DeleteCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
        {
            var categoryDto = await _categoryService.DeleteCategory(id);

            if (!categoryDto.IsSuccess)
            {
                return NotFound(categoryDto);
            }

            return NoContent();
        }
    }
}
