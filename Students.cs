namespace BlazorAppStandAlone

{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Mobile is required!")]
        [Phone(ErrorMessage = "Mobile is not valid!")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }


    }
}
