<?php

require '../lib/db.php';

/**
* Generate a License Key.
* Optional Suffix can be an integer or valid IPv4, either of which is converted to Base36 equivalent
* If Suffix is neither Numeric or IPv4, the string itself is appended
*
* @param   string  $suffix Append this to generated Key.
* @return  string
*/
function generate_license($suffix = null) {
    // Default tokens contain no "ambiguous" characters: 1,i,0,o
    if(isset($suffix)){
        // Fewer segments if appending suffix
        $num_segments = 3;
        $segment_chars = 6;
    }else{
        $num_segments = 4;
        $segment_chars = 5;
    }
    $tokens = 'ABCDEFGHJKLMNPQRSTUVWXYZ23456789';
    $license_string = '';
    // Build Default License String
    for ($i = 0; $i < $num_segments; $i++) {
        $segment = '';
        for ($j = 0; $j < $segment_chars; $j++) {
            $segment .= $tokens[rand(0, strlen($tokens)-1)];
        }
        $license_string .= $segment;
        if ($i < ($num_segments - 1)) {
            $license_string .= '-';
        }
    }
    // If provided, convert Suffix
    if(isset($suffix)){
        if(is_numeric($suffix)) {   // Userid provided
            $license_string .= '-'.strtoupper(base_convert($suffix,10,36));
        }else{
            $long = sprintf("%u\n", ip2long($suffix),true);
            if($suffix === long2ip($long) ) {
                $license_string .= '-'.strtoupper(base_convert($long,10,36));
            }else{
                $license_string .= '-'.strtoupper(str_ireplace(' ','-',$suffix));
            }
        }
    }
    return $license_string;
}

// get the HTTP method, path and body of the request
$method = $_SERVER['REQUEST_METHOD'];
$request = explode('/', trim($_SERVER['PATH_INFO'],'/'));
$input = json_decode(file_get_contents('php://input'),true);

$query="insert into `tbl_chats` (coloum_name) values('".$val."')";
$wisherID = db::getInstance()->dbquery($query);
 
// connect to the mysql database
//$link = mysqli_connect('localhost', 'user', 'pass', 'dbname');
//mysqli_set_charset($link,'utf8');
 
// retrieve the table and key from the path
//$table = preg_replace('/[^a-z0-9_]+/i','',array_shift($request));
//$key = array_shift($request)+0;
 
// escape the columns and values from the input object
//$columns = preg_replace('/[^a-z0-9_]+/i','',array_keys($input));
//$values = array_map(function ($value) use ($link) {
//  if ($value===null) return null;
//  return mysqli_real_escape_string($link,(string)$value);
//},array_values($input));
// 
//// build the SET part of the SQL command
//$set = '';
//for ($i=0;$i<count($columns);$i++) {
//  $set.=($i>0?',':'').'`'.$columns[$i].'`=';
//  $set.=($values[$i]===null?'NULL':'"'.$values[$i].'"');
//}
// 
//// create SQL based on HTTP method
//switch ($method) {
//  case 'GET':
//    $sql = "select * from `$table`".($key?" WHERE id=$key":''); break;
//  case 'PUT':
//    $sql = "update `$table` set $set where id=$key"; break;
//  case 'POST':
//    $sql = "insert into `$table` set $set"; break;
//  case 'DELETE':
//    $sql = "delete `$table` where id=$key"; break;
//}
 
// excecute SQL statement
//$result = mysqli_query($link,$sql);
 
// die if SQL statement failed
//if (!$result) {
//  http_response_code(404);
//  die(mysqli_error());
//}
 
// print results, insert id or affected row count
if ($method == 'GET') {
  //if (!$key) echo '[';
  //for ($i=0;$i<mysqli_num_rows($result);$i++) {
  //  echo ($i>0?',':'').json_encode(mysqli_fetch_object($result));
  //}
  //if (!$key) echo ']';
  echo generate_license($_SERVER['REMOTE_ADDR']);
} elseif ($method == 'POST') {
  //echo mysqli_insert_id($link);
} else {
  //echo mysqli_affected_rows($link);
}
 
// close mysql connection
//mysqli_close($link);
