# CSHP320A

homework03

Take the ListView topic and make the columns sortable.

Use the following data:

```
var users = new List<Models.User>();

users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

uxList.ItemsSource = users;
```

And use the following XAML from the exercise:

```
<ListView x:Name="uxList">
    <ListView.View>
        <GridView>
            <GridViewColumn DisplayMemberBinding="{Binding Name}">
            </GridViewColumn>
            <GridViewColumn DisplayMemberBinding="{Binding Password}">
            </GridViewColumn>
        </GridView>
    </ListView.View>
</ListView>
```

When you click on the Name column you should see the list in order (Dave, Lisa, Steve).

When you click on the Password column you should see the list in order (1DavePwd, 2StevePwd, 3LisaPwd)

Use the following links to help out:

http://www.wpf-tutorial.com/listview-control/listview-sorting/ (Links to an external site.)

http://stackoverflow.com/questions/31527455/how-do-i-get-a-click-event-from-a-gridviewcolumn-header (Links to an external site.)

Hint: Look at the GridViewColumnHeader element which is under the GridViewColumn

SecondWindow.xaml and SecondWindow.xaml.cs should be the only files that need to be modified.

Hint: You need to clear the SortDescriptions before adding to it.