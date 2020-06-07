<?php 

namespace app\controllers;

use Yii;
use yii\web\Controller;
use yii\web\NotFoundHttpException;

class DashboardController extends Controller{
    public function actionIndex()
    {
        //$searchModel = new ResPartnerSearch();
        //$dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('dashboard');
    }




}



?>