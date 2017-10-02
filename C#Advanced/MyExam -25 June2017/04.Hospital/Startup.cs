namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim();
            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            while (input != "Output")
            {
                var splitted = input.Split(' ').ToArray();

                var department = splitted[0];
                var doctor = splitted[1] + " " + splitted[2];
                var patient = splitted[3];

                if (!departments.ContainsKey(department))
                {
                    List<List<string>> room = new List<List<string>>();
                    List<string> beds = new List<string>();
                    beds.Add(patient);
                    room.Add(beds);

                    departments.Add(department, room);

                    if (!doctorPatients.ContainsKey(doctor))
                    {
                        List<string> patients = new List<string>();
                        patients.Add(patient);
                        doctorPatients.Add(doctor, patients);
                    }
                    else
                    {
                        doctorPatients[doctor].Add(patient);
                    }

                }
                else
                {
                    if (departments[department].Count <= 20)
                    {
                        if (departments[department][departments[department].Count - 1].Count < 3)
                        {
                            departments[department][departments[department].Count - 1].Add(patient);

                            if (!doctorPatients.ContainsKey(doctor))
                            {
                                List<string> patients = new List<string>();
                                patients.Add(patient);
                                doctorPatients.Add(doctor, patients);
                            }
                            else
                            {
                                doctorPatients[doctor].Add(patient);
                            }
                        }
                        else if (departments[department].Count < 20)
                        {
                            List<string> beds = new List<string>();
                            beds.Add(patient);
                            departments[department].Add(beds);

                            if (!doctorPatients.ContainsKey(doctor))
                            {
                                List<string> patients = new List<string>();
                                patients.Add(patient);
                                doctorPatients.Add(doctor, patients);
                            }
                            else
                            {
                                doctorPatients[doctor].Add(patient);
                            }
                        }


                    }
                    
                }

                input = Console.ReadLine().Trim();

            }

            input = Console.ReadLine().Trim();

            while (input != "End")
            {
                var splitted = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (splitted.Length == 1) // departments
                {
                    if (departments.ContainsKey(splitted[0]))
                    {
                        departments[splitted[0]].ForEach(r => r.ForEach(p => Console.WriteLine(p)));
                    }
                }
                else //doctor/ depart room
                {
                    if (departments.ContainsKey(splitted[0]))
                    {
                        if (int.Parse(splitted[1]) - 1 < departments[splitted[0]].Count && int.Parse(splitted[1]) - 1 >= 0)
                        {
                            departments[splitted[0]][int.Parse(splitted[1]) - 1].OrderBy(p => p).ToList().ForEach(p => Console.WriteLine(p));
                        }
                    }
                    else
                    {
                        if (doctorPatients.ContainsKey(input))
                        {
                            doctorPatients[input].OrderBy(p => p).ToList().ForEach(p => Console.WriteLine(p));
                        }
                    }
                }


                input = Console.ReadLine().Trim();
            }

        }
    }
}
