# webscraber

Simple console that uses [HtmlAgilityPack](https://html-agility-pack.net/) to parse links from a website, including subpages.

### Prerequisites

There must be a <nav> element on the webpage with the menu, like so

```
<nav class="navbar navbar-default">
</nav>

```

## Usage

```
git clone https://github.com/MunroRaymaker/webscraber
cd webscraber
dotnet run
```

Enter address of website, eg. http://www.contoso.com.
Enter css class of the nav element