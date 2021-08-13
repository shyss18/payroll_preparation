using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollPreparation.Api.ViewModels.Employee;
using PayrollPreparation.Application.DeleteEmployee.Commands;
using PayrollPreparation.Application.GetEmployee.Commands;
using PayrollPreparation.Application.GetEmployees.Commands;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <returns>Existing employee.</returns>
        /// <response code="200">Returns the employee with provided id.</response>
        /// <response code="400">If the employee is null.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            Employee employee = await _mediator.Send(new GetEmployeeCommand(id), cancellationToken);
            return Ok(employee.Adapt<EmployeeViewModel>());
        }

        /// <summary>
        /// Gets employees.
        /// </summary>
        /// <returns>Existing employees.</returns>
        /// <response code="200">Returns all existing employees.</response>
        /// <response code="400">If the employees are null.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ReadOnlyCollection<EmployeeViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            ReadOnlyCollection<Employee> employees = await _mediator.Send(new GetEmployeesCommand(), cancellationToken);
            return Ok(employees.Adapt<ReadOnlyCollection<EmployeeViewModel>>());
        }

        /// <summary>
        /// Creates an employee.
        /// </summary>
        /// <returns>Employee id.</returns>
        /// <response code="201">Returns the employee id.</response>
        /// <response code="400">If the employee hasn't been created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel employee,
            CancellationToken cancellationToken)
        {
            Guid id = await _mediator.Send(employee.Command.ToCommand(), cancellationToken);
            return Ok(id);
        }

        /// <summary>
        /// Changes an employee.
        /// </summary>
        /// <returns>Employee id.</returns>
        /// <response code="201">Returns the employee id.</response>
        /// <response code="400">If the employee hasn't been changed.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <returns>Employee id.</returns>
        /// <response code="201">Returns the employee id.</response>
        /// <response code="400">If the employee hasn't been deleted.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            Guid employeeId = await _mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
            return Ok(employeeId);
        }
    }
}