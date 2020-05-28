<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Res Partner Categories';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-partner-category-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Res Partner Category', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'parent_path:ntext',
            'name:ntext',
            'color',
            'parent_id',
            //'active',
            //'create_uid',
            //'create_date',
            //'write_uid',
            //'write_date',
            //'trial509',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
