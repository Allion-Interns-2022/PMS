using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSWebAPI.Controllers
{
    [Route("api/siblings")]
    [ApiController]
    //[Authorize]
    public class SiblingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SiblingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<SiblingsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var siblingList = await _unitOfWork.SiblingRepository.GetAll();
                return Ok(siblingList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SiblingsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var existSibling = await _unitOfWork.SiblingRepository.GetById(id);
                if (existSibling != null)
                {
                    return Ok(existSibling);
                }
                else
                {
                    return BadRequest("Sibling is not available");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SiblingsController>/5
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetSiblingByStudentId(int id)
        {
            try
            {
                var existSibling = await _unitOfWork.SiblingRepository.GetSiblingByStudentId(id);
                if (existSibling != null)
                {
                    return Ok(existSibling);
                }
                else
                {
                    return BadRequest("No siblings available for selected student.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SiblingsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sibling entity)
        {
            try
            {
                bool isAdded = await _unitOfWork.SiblingRepository.AddEntity(entity);
                           await _unitOfWork.CompleteAsync();

                if (isAdded)
                {
                    return Ok("Sibling is added.");
                }
                else
                {
                    return BadRequest("Something is wrong with input.");
                }   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SiblingsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sibling entity)
        {
            try
            {
                var existSibling = await _unitOfWork.SiblingRepository.GetById(id);

                if (existSibling != null)
                {
                    existSibling.FullName = entity.FullName;
                    existSibling.EducationalInstitute = entity.EducationalInstitute;
                    existSibling.AcademicYear = entity.AcademicYear;
                    existSibling.StudentId = entity.StudentId;

                    bool isEdited = await _unitOfWork.SiblingRepository.UpdateEntity(existSibling);
                    await _unitOfWork.CompleteAsync();

                    if (isEdited)
                    {
                        return Ok("Sibling is updated.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("Sibling is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SiblingsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existSibling = await _unitOfWork.SiblingRepository.GetById(id);
                if (existSibling != null)
                {
                    bool isDeleted = await _unitOfWork.SiblingRepository.DeleteEntity(id);
                    await _unitOfWork.CompleteAsync();

                    if (isDeleted)
                    {
                        return Ok("Sibling is deleted.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("Sibling is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
