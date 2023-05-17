using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSWebAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    //[Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {
                var studentList = await _unitOfWork.StudentRepository.GetAll();
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var existstudent = await _unitOfWork.StudentRepository.GetById(id);
                if (existstudent != null)
                {
                    return Ok(existstudent);
                }
                else
                {
                    return BadRequest("Student is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var existstudent = await _unitOfWork.StudentRepository.GetStudentByName(name);
                if (existstudent != null)
                {
                    return Ok(existstudent);
                }
                else
                {
                    return BadRequest("Student is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HostelStudent entity)
        {
            try
            {
                bool isAdded = await _unitOfWork.StudentRepository.AddEntity(entity);
                               await _unitOfWork.CompleteAsync();
                if (isAdded)
                {
                    return Ok("Student is added.");
                }
                else
                {
                    return BadRequest("Something is wrong with the input.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HostelStudent entity)
        {
            try
            {
                var existstudent = await _unitOfWork.StudentRepository.GetById(id);
                if (existstudent != null)
                {
                    existstudent.Id = id;
                    existstudent.FullName = entity.FullName;
                    existstudent.NIC = entity.NIC;
                    existstudent.Gender = entity.Gender;
                    existstudent.Address = entity.Address;
                    existstudent.Contact = entity.Contact;
                    existstudent.Distance = entity.Distance;
                    existstudent.Remarks = entity.Remarks;
                    existstudent.SubmitDate = entity.SubmitDate;
                    existstudent.MaritalStatus = entity.MaritalStatus;
                    existstudent.FatherOccupation = entity.FatherOccupation;
                    existstudent.MotherOccupation = entity.MotherOccupation;
                    existstudent.FatherIncome = entity.FatherIncome;
                    existstudent.MotherIncome = entity.MotherIncome;

                    bool isEdited = await _unitOfWork.StudentRepository.UpdateEntity(existstudent);
                                    await _unitOfWork.CompleteAsync();
                    if (isEdited)
                    {
                        return Ok("Student is updated.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with the input.");
                    }
                }
                else
                {
                    return BadRequest("Student is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existstudent = await _unitOfWork.StudentRepository.GetById(id);
                if (existstudent != null)
                {
                    bool isDeleted = await _unitOfWork.StudentRepository.DeleteEntity(id);
                                     await _unitOfWork.CompleteAsync();
                    if (isDeleted)
                    {
                        return Ok("Student is deleted.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with the input.");
                    }
                }
                else
                {
                    return BadRequest("Student is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
