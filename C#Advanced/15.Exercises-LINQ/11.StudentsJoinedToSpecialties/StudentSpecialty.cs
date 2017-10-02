namespace _11.StudentsJoinedToSpecialties
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string specialityName, string facNum)
        {
            this.SpecialityName = specialityName;
            this.FacultyNumbr = facNum;
        }

        public string SpecialityName { get; set; }

        public string FacultyNumbr { get; set; }
    }
}
