IMAGE := mcr.microsoft.com/dotnet/sdk:7.0
DOPTS := --rm -it -v $(shell pwd):/workdir -w /workdir $(IMAGE)

run:
	dotnet run

run-on-docker:
	docker run $(DOPTS) dotnet run

build:
	$(DOTNET) build
	@ echo ""
	@ echo "Executable File => ./bin/Debug/net7.0/Calculator"

