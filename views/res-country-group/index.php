<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Res Country Groups';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-country-group-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Res Country Group', ['create'], ['class' => 'btn btn-success']) ?>
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
            //'trial454',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
