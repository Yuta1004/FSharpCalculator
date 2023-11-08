DOTNET := dotnet

run:
	@ $(DOTNET) run

build:
	@ $(DOTNET) build
	@ echo ""
	@ echo "Executable File => ./bin/Debug/net7.0/Calculator"

