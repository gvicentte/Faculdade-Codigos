package org.utils;

import java.nio.file.Paths;

public class PathFXML {
    public static String pathFXML(){
        String path = "src/main/java/org/view";
        return Paths.get(path).toAbsolutePath().toString();
    }
}
