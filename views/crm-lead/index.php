<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\ResPartnerSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Oportunidades';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="crm-lead-index">
<div class="sale-order-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Oportunidad', ['create'], ['class' => 'btn btn-success']) ?>
    </p>



    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            //'id',
            'name',
            'partner_name',
            'type',
            'priority',
            'team_name',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
