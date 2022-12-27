# CSharp
C# projects

- **2022/12/1** Solution Explorer 에서 Dependencies 에서 Analyzers에서 경고아이콘이 나타나는 경우에 
해당 Project의 *.csproj 파일에서 <TargetFramework>net6.0</TargetFramework>을 수정하여 원하는 것으로 
수정하면 문제가 해결된다. 

- **2022/12/2** Nuget package를 만들 때는 *.csproj 파일에 ```<PackageReadmeFile>filename</PackageReadmeFile>```을 지정해 주어야 함.

- **2022/12/3** Top program style의 프로젝트에서 Program.c 에 아무 실행코드도 입력하지 않으면 Main이 정의 되지 않게 됨.

- **2022/12/10** 빌드된 실행파일을 다른 곳으로 옮겨서 실행하려면 생성된 exe파일과 함께 *.runtimeconfig.json 및 사용하는 dll 파일도 같이 복사해 주어야 함.

- **2022/12/13** DataBase example에서 bool deleted = await a.Database.EnsureDeletedAsync(); 코드를 실행하면 프로그램이 다운됨. SqlServer를 사용하는 경우에만 현상이 발생함. SQLite을 사용하는 경우에는 정상적으로 실행이 됨. 뭔가 DataBase에 연결이 안되는 것 같은 데 다른 예제에서는 정상적으로 연결되고 실행이 되었음.
- - 해결함. main 에서 await으로 호출해야 정상적으로 동작함. async 함수를 await으로 호출하지 않으면 바로 프로그램이 종료함. Chap10/CoursesAndStudents project.

- **2022/12/21** Error like "InvalidOperationException: Unable to resolve service for type 'WebApplication1.Data.BloggerRepository' while attempting to activate 'WebApplication1.Controllers.BlogController'." occurs when there is no Dependency Injection for corresponding Class.

- **2022/12/23** The WebApi function as GetCustomers(string? country) can be requested as /api/customers, but GetCustomers(string country) cannot be called without country parametr. It generate an error

- **2022/12/24** Property set function like 
```
public int IntValue
{
  get => IntValue;
}
```
will define infinite loop for get_IntValue.

- **2022/12/25** To isntall dotnet work tools for .NET 6, use dotnet workload install wasm-tools-net6
- - There will be error in `_Hosts.cshtm` if one define the same routing page like "Object reference not set to an instance of an object."

- **2022/12/26** The working example for GraphQL example is based on the code
```
public class StarWarsQuery : ObjectGraphType
{
  public StarWarsQuery()
  {
    Field<DroidType>("hero")
      .Resolve(context => new Droid { Id = "1", Name = "R2-D2" });
  }
}
```

- **2022/12/27** If `Greeter.GreeterClient` does not appear in intellisense, it means that corresponding `GreetGrpc.cs` file was not generated corrected in client side. You can remove `greet.proto` and generate a new file and set correct proprety for `Client Only` and `Protobuf compile`. This will resolve the problem.
 
