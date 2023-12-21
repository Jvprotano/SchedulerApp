using AppAgendamentos.Enums;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace AppAgendamentos.ViewModels;
public class CompanyViewModel : BaseViewModel
{
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }
    public string Description { get; set; }
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; }
    [Display(Name = "Auto Generate my Image Logo using AI")]
    public bool AutoGeneratedImage { get; set; }
    [Display(Name = "City")]
    public int? CityId { get; set; }
    public string Address { get; set; }
    [Display(Name = "Number")]
    public string AddressNumber { get; set; }
    public string PostalCode { get; set; }
    [Display(Name = "Is not a physical location")]
    public bool IsVirtual { get; set; }


    public IFormFile ImageFile { get; set; }


    [Display(Name = "Categories")]
    public List<int> SelectedCategoryIds { get; set; } = [];
    [Display(Name = "Services Offered")]
    public List<string> SelectedExistingNames { get; set; } = [];
    public List<SelectListItem> CategoriesSelectIds { get; set; } = LoadCategories();
    public List<SelectListItem> ServicesExistingOptionsSelect { get; set; } = [];
    public List<SelectListItem> CitiesSelect { get; set; }
    public List<CompanyOpeningHours> OpenAISchedules { get; set; } = new List<CompanyOpeningHours>();
    public List<CompanyOpeningHours> OpeningHours { get; set; } = LoadDefaultOpeningHours();
    public List<CompanyServiceOffered> ServicesOffered { get; set; } = new List<CompanyServiceOffered>();

    private static List<SelectListItem> LoadCategories()
    {
        List<SelectListItem> categories = new List<SelectListItem>();

        Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>().ToList().ForEach(category => categories.Add(
            new SelectListItem(text: category.ToString(), value: ((int)category).ToString())));

        return categories;
    }
    private static List<CompanyOpeningHours> LoadDefaultOpeningHours()
    {
        List<CompanyOpeningHours> defaultOpeningHours = [];

        Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList().ForEach(dayOfWeek => defaultOpeningHours.Add(
            new CompanyOpeningHours
            {
                DayOfWeek = dayOfWeek,
                OpeningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            }));

        return defaultOpeningHours;
    }
}