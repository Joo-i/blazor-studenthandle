namespace BlazorAppStandAlone.components;

public partial class Students
{
    [Inject] private HttpClient? Http { get; set; } = default!;

    private Student? student = new();

    List<Student> ?students = [];

    private string? search = string.Empty;
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        //TODO:: using HttpClient call https://students.innopack.app/api/students to fill students
        
        if (firstRender && !students.Any())
        {
            students = await Http.GetFromJsonAsync<List<Student>>("api/students");

            student.Name = "enter your name";
            student.Mobile = "mobile";
            student.Age =0;

            StateHasChanged();
        }
    }

    private async Task HandleValidSubmit()
    {
        string studentSerialized = JsonSerializer.Serialize(student);
        Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);

        if (validStudent is not null)
        {
            if (validStudent.Id >= 0)
            {
                var response = await Http.PutAsJsonAsync($"api/students", validStudent);///this doesnt work and using/{id} doesnt work as well but the student get replaced in the current table
            }
            else
            {
                var response = await Http.PostAsJsonAsync("api/students", validStudent);

                if (response.IsSuccessStatusCode)
                {
                    var created = await response.Content.ReadFromJsonAsync<Student>();
                    if (created is not null)
                        students.Add(created);
                }
                else
                {
                    students.Add(validStudent);
                }

                student = new Student();
            }

        //Search With name if exits get it by index and edit it in list if not add it to list
        //TODO:: using HttpClient call https://students.innopack.app/api/students to post and put
        }
    }

    
    private void EditStudent(Student toBeEditedStudent)
    {
        student = toBeEditedStudent;

        StateHasChanged();
    }

}