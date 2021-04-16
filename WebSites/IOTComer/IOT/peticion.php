<?php
	$v1 = $_GET["v1"]; 
	$v2 = $_GET["v2"]; 
	$v3 =$_GET ["v3"];
	
	echo "Recibido";
	$url = "http://". $v1 ."/". $v2 ."/". $v3;
	echo $url;
	$curl = curl_init();
	curl_setopt($curl, CURLOPT_URL, $url);

	$output = curl_exec($curl);
	curl_close($curl);
	echo "hecho";
	
?>
