<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\UtmSourceSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Utm Sources';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="utm-source-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Utm Source', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name:ntext',
            'create_uid',
            'create_date',
            'write_uid',
            //'write_date',
            //'trial581',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
