<?php
	$v1 = $_GET["v1"]; 
	$v2 = $_GET["v2"]; 
	$v3 =$_GET ["v3"];
	$url = "http://". $v1 ."/rest.php?riscei=". $v2 ."&evento=". $v3;
	$curl = curl_init();
	curl_setopt($curl, CURLOPT_URL, $url);

	$output = curl_exec($curl);
	curl_close($curl);
	print_r($output);
?>
