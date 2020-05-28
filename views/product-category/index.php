<?php

use yii\helpers\Html;
use yii\grid\GridView;

$this->title = 'Product Categories';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="product-category-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Product Category', ['create'], ['class' => 'btn btn-success']) ?>
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
            'complete_name:ntext',
            'parent_id',
            //'create_uid',
            //'create_date',
            //'write_uid',
            //'write_date',
            //'removal_strategy_id',
            //'trial362',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
