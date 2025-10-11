module org.sysimc {
    requires javafx.controls;
    requires javafx.fxml;
    opens org.controller to  javafx.fxml;
    exports org.controller to javafx.fxml;
    exports org;
    opens org to javafx.fxml;
}