using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSWebAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<PatientsController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {
                var patientList = await _unitOfWork.PatientRepository.GetAll();
                return Ok(patientList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var existpatient = await _unitOfWork.PatientRepository.GetById(id);
                if (existpatient != null)
                {
                    return Ok(existpatient);
                }
                else
                {
                    return BadRequest("Patient is not available.");
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
                var existpatient = await _unitOfWork.PatientRepository.GetPatientByName(name);
                if (existpatient != null)
                {
                    return Ok(existpatient);
                }
                else
                {
                    return BadRequest("Patient is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<PatientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient entity)
        {
            try
            {
                bool isAdded = await _unitOfWork.PatientRepository.AddEntity(entity);
                               await _unitOfWork.CompleteAsync();
                if (isAdded)
                {
                    return Ok("Patient is added.");
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

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Patient entity)
        {
            try
            {
                var existpatient = await _unitOfWork.PatientRepository.GetById(id);
                if (existpatient != null)
                {
                    existpatient.Id = id;
                    existpatient.Name = entity.Name;
                    existpatient.DOB = entity.DOB;
                    existpatient.WeightKG = entity.WeightKG;
                    existpatient.HeightCM = entity.HeightCM;
                    existpatient.Address = entity.Address;
                    existpatient.Contact = entity.Contact;
                    existpatient.EmergencyContact = entity.EmergencyContact;

                    bool isEdited = await _unitOfWork.PatientRepository.UpdateEntity(existpatient);
                                    await _unitOfWork.CompleteAsync();
                    if (isEdited)
                    {
                        return Ok("Patient is updated.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with the input.");
                    }
                }
                else
                {
                    return BadRequest("Patient is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existpatient = await _unitOfWork.PatientRepository.GetById(id);
                if (existpatient != null)
                {
                    bool isDeleted = await _unitOfWork.PatientRepository.DeleteEntity(id);
                                     await _unitOfWork.CompleteAsync();
                    if (isDeleted)
                    {
                        return Ok("Patient is deleted.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with the input.");
                    }
                }
                else
                {
                    return BadRequest("Patient is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
