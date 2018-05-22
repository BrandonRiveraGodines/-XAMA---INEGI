<?php
  session_start();
  if (isset($_SESSION['name'])) {
    echo '<h1>Ya has iniciado sesión</h1> <br> <button type="button" onclick="location.href=\'logout.php\'">Cerrar sesión</button>';
  }else {
    require_once 'include/DB_Functions.php';
    $db = new DB_Functions();
    // json response array
    $response = array("error" => FALSE);

    if (isset($_POST['email']) && isset($_POST['password'])) {
        // receiving the post params
        $email = $_POST['email'];
        $password = $_POST['password'];
        // get the user by email and password
        $user = $db->getUserByEmailAndPassword($email, $password);
        if ($user != false) {
            $_SESSION['name']=$user['name'];
            // use is found
            $response["error"] = FALSE;
            $response["uid"] = $user["unique_id"];
            $response["user"]["name"] = $user["name"];
            $response["user"]["email"] = $user["email"];
            $response["user"]["created_at"] = $user["created_at"];
            $response["user"]["updated_at"] = $user["updated_at"];
            echo json_encode($response);
            echo '<script type = "text/javascript">alert(\'Si existe el usuario.\');</script>';
        } else {
            // user is not found with the credentials
            $response["error"] = TRUE;
            $response["error_msg"] = "Login credentials are wrong. Please try again!";
            echo json_encode($response);
            echo '<script type = "text/javascript">alert(\'Error. \');</script>';
        }
    } else {
        // required post params is missing
        $response["error"] = TRUE;
        $response["error_msg"] = "Required parameters email or password is missing!";
        echo json_encode($response);
        echo '<script type = "text/javascript">alert(\'Error. \');</script>';
    }
  }
//$email = $_POST['email'];
//$password = md5($_POST['pass']);
//$query = mysql_query ("SELECT * FROM admin WHERE email = '$_POST[email]' AND password = '$password'");



?>
