
    <?php
    function searchForTextInFiles($directory, $search) {
        $iterator = new RecursiveIteratorIterator(new RecursiveDirectoryIterator($directory));
    
        foreach ($iterator as $file) {
            if ($file->isFile()) {
                $content = file($file->getPathname());
                $lineNumber = 0;
                foreach ($content as $line) {
                    $lineNumber++;
                    if (strpos($line, $search) !== false) {
                        echo "Found in file: " . $file->getPathname() . " | Line: " . $lineNumber;
                        if (!empty($_POST['directory']) && !empty($_POST['search_string'])) {
                            echo "<br>";
                        }
                        else{
                            echo "\n";
                        }

                        
                    }
                }
            }
        }
    }
    // Проверяем, как передаются данные: через POST или через аргументы командной строки
if (!empty($_POST['directory']) && !empty($_POST['search_string'])) {
    $directory = $_POST['directory'];
    $search = $_POST['search_string'];
} elseif (!empty($argv[1]) && !empty($argv[2])) {
    $directory = $argv[1];
    $search = $argv[2];
} 

    // Поиск и вывод результатов
    searchForTextInFiles($directory, $search);
    ?>
