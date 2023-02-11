using AnimalShelter;
using AnimalShelter.Animals;
using Autofac;

namespace AnimalShelterTests.Animals;

public class AnimalsModelTests : InMemoryDbTests
{
    [Fact]
    public void AddAnimal_ShouldAddAnimalToDbSet()
    {
        // Arrange
        var context = App.AppContainer.Resolve<ShelterContext>();
        var model = new AnimalsModel(context);
        var animal = new Animal
        {
            Name = "Test",
            Species = Species.Bird,
            Gender = Gender.Male,
            Size = Size.Medium,
            Age = 15,
            Description = "Talkactive",
            Adopted = false
        };

        // Act
        model.AddAnimal(animal);

        // Assert
        Assert.Contains(animal, context.Animals.ToList());
    }

    [Fact]
    public void DeleteAnimal_ShouldRemoveSelectedAnimalFromDbSet()
    {
        // Arrange
        var context = App.AppContainer.Resolve<ShelterContext>();
        var model = new AnimalsModel(context);
        var animal = new Animal
        {
            Name = "Test",
            Species = Species.Bird,
            Gender = Gender.Male,
            Size = Size.Medium,
            Age = 15,
            Description = "Talkactive",
            Adopted = false
        };
        context.Animals.Add(animal);
        context.SaveChanges();
        Assert.Contains(animal, context.Animals.ToList());
        model.SelectedAnimal = animal;

        //Act
        model.DeleteAnimal.Execute(null);

        // Assert
        Assert.DoesNotContain(animal, context.Animals.ToList());
    }

    [Fact]
    public void SelectedAnimal_ShouldFetchSelectedAnimalActions()
    {
        // Arrange
        var context = App.AppContainer.Resolve<ShelterContext>();
        var model = new AnimalsModel(context);
        var animal = new Animal
        {
            Id = 1,
            Name = "Test",
            Species = Species.Bird,
            Gender = Gender.Male,
            Size = Size.Medium,
            Age = 15,
            Description = "Talkactive",
            Adopted = false
        };
        var action = new ShelterAction
        {
            Name = "TestAction",
            Description = "Test Description",
            Animal = animal,
        };

        context.Animals.Add(animal);
        context.Actions.Add(action);
        context.SaveChanges();
        Assert.Contains(animal, context.Animals.ToList());
        Assert.Contains(action, context.Actions.ToList());
        model.SelectedAnimal = animal;

        //Act
        var selectedAnimalActions = model.SelectedAnimalActions;
        // Assert
        Assert.Contains(action, selectedAnimalActions);
    }

    [Fact]
    public void MakeRequest_ShouldAddActionToDatabase()
    {
        // Arrange
        var context = App.AppContainer.Resolve<ShelterContext>();
        var model = new AnimalsModel(context);
        var animal = new Animal
        {
            Id = 1,
            Name = "Test",
            Species = Species.Bird,
            Gender = Gender.Male,
            Size = Size.Medium,
            Age = 15,
            Description = "Talkactive",
            Adopted = false
        };
        var request = new ActionRequest
        {
            Name = "TestRequest",
            Type = ShelterActionType.VetVisit,
            Description = "testDescription"
        };
        var expectedAction = new ShelterAction
        {
            Id = 1,
            Name = "TestRequest",
            Type = ShelterActionType.VetVisit,
            Description = "testDescription",
            Assignee = null,
            Animal = animal,
            Status = ShelterActionStatus.Requested
        };

        context.Animals.Add(animal);
        context.SaveChanges();
        Assert.Contains(animal, context.Animals.ToList());
        model.SelectedAnimal = animal;

        //Act
        model.MakeRequest.Execute(request);
        // Assert
        Assert.Contains(context.Actions.ToList(),
            x => x.Id == expectedAction.Id &&
                 x.Name == expectedAction.Name &&
                 x.Type == expectedAction.Type &&
                 x.Description == expectedAction.Description &&
                 x.Assignee == expectedAction.Assignee &&
                 x.Animal == expectedAction.Animal &&
                 x.Status == expectedAction.Status
        );
    }
}