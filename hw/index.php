<!DOCTYPE html>
<html>
<head>
    <title>Поиск текстовой строки в файлах</title>
</head>
<body>
    <h1>Поиск текстовой строки в файлах</h1>
    <form action="output.php" method="post">
        <label for="directory">Введите путь к директории:</label><br>
        <input type="text" id="directory" name="directory"><br><br>
        
        <label>Введите текстовую строку для поиска:</label><br>
        <input type="text" id="search_string" name="search_string"><br><br>
        
        <input type="submit" value="Поиск">
    </form>
    <?php
    
    ?>
</body>
</html>
