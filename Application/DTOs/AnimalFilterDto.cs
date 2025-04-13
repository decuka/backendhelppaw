// Application/DTOs/AnimalFilterDto.cs
namespace HelPaw.Application.DTOs.Animal;

public class AnimalFilterDto
{
    public string? Type { get; set; }              
    public string? Gender { get; set; }            
    public int? MinAge { get; set; }               
    public int? MaxAge { get; set; }               
    public string? Size { get; set; }              
    public string? Condition { get; set; }         
    public bool? IsVaccinated { get; set; }        
    public bool? IsSterilized { get; set; }  
    public string? City { get; set; }               
    public bool? IsActive { get; set; }             
    public Guid? ShelterId { get; set; }            
}
