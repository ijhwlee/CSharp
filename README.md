# CSharp
C# projects

- **2022/12/1** Solution Explorer 에서 Dependencies 에서 Analyzers에서 경고아이콘이 나타나는 경우에 
해당 Project의 *.csproj 파일에서 <TargetFramework>net6.0</TargetFramework>을 수정하여 원하는 것으로 
수정하면 문제가 해결된다. 

- **2022/12/2** Nuget package를 만들 때는 *.csproj 파일에 ```<PackageReadmeFile>filename</PackageReadmeFile>```을 지정해 주어야 함.

- **2022/12/3** Tope program style의 프로젝트에서 Program.c 에 아무 실행코드도 입력하지 않으면 Main이 정의 되지 않게 됨.
