<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Utm Campaigns';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="utm-campaign-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Utm Campaign', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name:ntext',
            'user_id',
            'stage_id',
            'is_website',
            //'color',
            //'create_uid',
            //'create_date',
            //'write_uid',
            //'write_date',
            //'company_id',
            //'trial562',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
