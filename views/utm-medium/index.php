<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Utm Media';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="utm-medium-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Utm Medium', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name:ntext',
            'active',
            'create_uid',
            'create_date',
            //'write_uid',
            //'write_date',
            //'trial568',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
