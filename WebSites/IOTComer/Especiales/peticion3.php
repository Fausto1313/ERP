<?php
	$v1 = $_GET["v1"]; 
	$v2 = $_GET["v2"]; 
	$accion = $_GET["v3"];
	if($accion == "Pista"){
		$url = "http://". $v1 ."/mp3.php?track=". $v2 ;
	}
	else{
		$url = "http://". $v1 ."/mp3.php?accion=". $v2 ;
	}
	//$url = "http://". $v1 ."/mp3.php?track=". $v2 ;
	$curl = curl_init();
	curl_setopt($curl, CURLOPT_URL, $url);

	$output = curl_exec($curl);
	curl_close($curl);
	print_r($output);
?>
