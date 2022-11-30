//using NetCafeUCN.DAL.Model;

//namespace NetCafeUCN.API.Conversion
//{
//    public static class IConversion<T, U>
//    {
//        public static IEnumerable<T> ToDtos(IEnumerable<U> o)
//        {
//            foreach (var gamingStation in o)
//            {
//                yield return gamingStation.ToDto();
//            }
//        }
//        public static T ToDto(U u)
//        {
//            return u.CopyPropertiesTo(new T());
//        }
//        public IEnumerable<U> FromDtos(IEnumerable<T> t);
//        public U FromDto(T t);
//    }
//}
