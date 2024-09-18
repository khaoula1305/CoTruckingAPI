using System.ComponentModel.DataAnnotations;

public enum Title
{
    [Display(Name = "Ms.")]
    Ms,

    [Display(Name = "Miss")]
    Miss,

    [Display(Name = "Mr.")]
    Mr
}