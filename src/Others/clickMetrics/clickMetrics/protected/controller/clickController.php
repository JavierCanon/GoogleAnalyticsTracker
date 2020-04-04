<?php
//Controller class for the requests
class clickController {


	public function init(){
		print $config->db_name;
	}
}

$cont = new clickController();
$cont->init();