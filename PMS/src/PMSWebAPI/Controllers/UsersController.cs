using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userList = await _unitOfWork.UserRepository.GetAll();
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
            
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var existuser = await _unitOfWork.UserRepository.GetById(id);
                if (existuser != null)
                {
                    return Ok(existuser);
                }
                else
                {
                    return BadRequest("User is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User entity)
        {
            try
            {
                bool isAdded = await _unitOfWork.UserRepository.AddEntity(entity);
                               await _unitOfWork.CompleteAsync();
                if (isAdded)
                {
                    return Ok("User is added.");
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

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User entity)
        {
            try
            {
                var existuser = await _unitOfWork.UserRepository.GetById(id);
                if (existuser != null)
                {
                    existuser.Id = id;
                    existuser.FirstName = entity.FirstName;
                    existuser.LastName = entity.LastName;
                    existuser.Username = entity.Username;
                    existuser.Password = entity.Password;
                    existuser.LastModified = entity.LastModified;
                    existuser.LastModifiedBy = entity.LastModifiedBy;

                    bool isEdited = await _unitOfWork.UserRepository.UpdateEntity(existuser);
                                   await _unitOfWork.CompleteAsync();

                    if (isEdited)
                    {
                        return Ok("User is updated.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("User is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existuser = await _unitOfWork.UserRepository.GetById(id);
                if (existuser != null)
                {
                    bool isDeleted = await _unitOfWork.UserRepository.DeleteEntity(id);
                    await _unitOfWork.CompleteAsync();

                    if (isDeleted)
                    {
                        return Ok("User is deleted.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("User is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
