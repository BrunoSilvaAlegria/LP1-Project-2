# Yet Another Dungeon Crawler
#### By Bruno Alegria a22302942, Ivan Emídio a22301234, Fábio Ribeiro a22102432
##### Linguagens de Programação I - Projeto 2
[Project's Git link](https://github.com/BrunoSilvaAlegria/LP1-Project-2.git)

### Bruno Alegria
+ Creator of the git repository
+ Main responsible for the README.md file
+ UML diagram creator
+ View classes main responsible
+ Controller class responsible

### Ivan Emídio
+ Board class main responsible
+ Controller class main responsible

### Fábio Ribeiro
+ XML Documentation main responsible
---
## The Dungeon's Map
![Dungeon Map](https://github.com/BrunoSilvaAlegria/LP1-Project-2/assets/160754544/0dfb9770-621e-4baa-a7b1-d5411e8c58ab)
---
## Architecture

#### Project's Organization and non-trivial Algorithms

#### UML Diagram

LP1 Project II Diagram | Bruno Alegria | Ivan Emídio | Fábio Ribeiro
 
``` mermaid
classDiagram
    class Program {

    }
    class TrueView {

    }
    class Controller {
        
    }
    class IView {
        <<interface>>
    }
    class Player {

    }
    class Enemy {

    }
    class Item {

    }
    class Room {

    }
    class Board {

    }

    IView <|.. TrueView
    Program --> TrueView
    Program o--> Controller
    Player --> Item
    Board --> Room
    Board --> Item
    Controller --> IView
    Controller --> Player
    Controller --> Board
    Controller --> Enemy
    Controller --> Item
    Controller o--> Room    
    
```
---
## References

#### Ideas

Bruno - Use IView interface to organize the writing and reading methods described in TrueView class, and use them on the Controller class (following the MVC format).

#### AI Code

#### Open Code

#### Libraries
* [Mermaid diagram on draw.io](https://www.drawio.com/blog/mermaid-diagrams)
* [How to add a .png file to Github with git lfs](https://josh-ops.com/posts/add-files-to-git-lfs/)

