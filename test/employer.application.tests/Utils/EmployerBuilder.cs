using employers.domain.Entities.Employer;

namespace employer.application.tests.Utils
{
    public class EmployerBuilder
    {
        private int _id;
        private string _name;
        private int _idDepartament;

        public static EmployerBuilder Novo()
        {
            return new EmployerBuilder();
        }

        public EmployerBuilder WhithId(int id)
        {
            _id = id;
            return this;
        }
        public EmployerBuilder WhithName(string name)
        {
            _name = name;
            return this;
        }
        public EmployerBuilder WhithIdDepartment(int idDepartament)
        {
            _idDepartament = idDepartament;
            return this;
        }

        public EmployeeEntity Build()
        {
            var employer = new EmployeeEntity { Id = _id, IdDepartament = _idDepartament, Name = _name };
            return employer;
        }
    }
}
