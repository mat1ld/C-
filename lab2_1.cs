using System;

class Student : IEquatable<Student>
{
   
    private string name;
    private string surname;
    private string group;
    private string id;
    private int age;
    private int course;

    
    public Student(string name, string surname, string group, string id, int age, int course)
    {
        
        if (name == null || surname == null || group == null || age == null || id == null || course == null)
        {
            throw new ArgumentNullException("Необходимо указать все поля для класса (Имя, фамилия, возраст, курс, ID, группу.");
        }

        this.name = name;
        this.surname = surname;
        this.group = group;
        this.id = id;
        this.age = age;
        this.course = course;
       


        
        if (course < 1 || course > 4)
        {
            throw new ArgumentOutOfRangeException("Значение поля курс должно быть от 1 до 4");
        }
        this.course = course;
    }

    
    public string FullName => name;
    public string Group => group;
    public string RecordBookNumber => id;
    public int Age => age;
    public string Surname => surname;   
    public int Course => course;

   
    public override string ToString()
    {
        return $"Имя: {name}, фамилия: {surname}, возраст: {age}, учебная группа: {group}, номер зачётной книжки: {id}, курс: {course}";
    }

    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Student other = (Student)obj;
        return this.name == other.name && this.surname == other.surname && this.group == other.group && this.id == other.id && this.course == other.course && this.age==other.age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, surname, age, group, id, course);
    }

    
    public bool Equals(Student other)
    {
        if (other == null)
        {
            return false;
        }
        return this.name == other.name && this.surname == other.surname && this.age == other.age && this.group == other.group && this.id == other.id && this.course == other.course;
    }
}

class Program
{
    static void Main()
    {
        try
        {
           
            Student student1 = new Student("Петр", "Великий", "КБ-01-17", "1", 19, 2);
            Student student2 = new Student("Иван", "Сидорчук", "КБ-02-16", "17",20,  3);
            Student student3 = new Student("Глеб", "Иванов", "ИБ-10-15", "3", 21, 4);

           
            Console.WriteLine(student1);
            Console.WriteLine(student2);
            Console.WriteLine(student3);

            Int64 long1 = student1.GetHashCode();
            Console.WriteLine($"Сравнение студентов 1 и 2: {student1.Equals(student2)}");
            Console.WriteLine($"Хеш-код студента 1: " + long1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}