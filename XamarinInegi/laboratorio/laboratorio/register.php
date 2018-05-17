<?php
require 'include/DB_Functions.php';
$db = new DB_Functions();

// json response array
$response = array("error" => FALSE);

if (!empty($_POST['name']) && !empty($_POST['email']) && !empty($_POST['password'])) {
  echo "todo correcto en el llenado de los campos \n";
    // receiving the post params
    $name = $_POST['name'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    // check if user is already existed with the same email

    if ($db->isUserExisted($email)) {
        // user already existed
        echo "El usuario existe";
        $response["error"] = TRUE;
        $response["error_msg"] = "User already existed with " . $email;
        echo json_encode($response);
        echo '<script type = "text/javascript">alert(\'Error, usuario ya registrado. \');</script>';
        echo '<script type = "text/javascript">alert(\'Error, usuario ya registrado. \');</script>';
    }

    else {
        // create a new user
        $user = $db->storeUser($name, $email, $password);
        if ($user) {
          echo "Pasa el IF de register.php";
            // user stored successfully
            $response["error"] = FALSE;
            $response["uid"] = $user["unique_id"];
            $response["user"]["name"] = $user["name"];
            $response["user"]["email"] = $user["email"];
            $response["user"]["created_at"] = $user["created_at"];
            $response["user"]["updated_at"] = $user["updated_at"];
            echo json_encode($response);
            header ('Location: index.php');
        } else {
            // user failed to store
            $response["error"] = TRUE;
            $response["error_msg"] = "Unknown error occurred in registration!";
            echo json_encode($response);
        }
    }
} else {
    $response["error"] = TRUE;
    $response["error_msg"] = "Required parameters (name, email or password) is missing!";
   // echo json_encode($response);
    echo '<script type = "text/javascript">alert(\'Llena todos los campos. \');</script>';
    echo '<script type = "text/javascript">alert(\'Llena todos los campos. \');</script>';
}
?>
