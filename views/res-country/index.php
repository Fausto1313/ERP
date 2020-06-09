<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Paises';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-country-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Pais', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name:ntext',
            'code',
            'address_format:ntext',
            'address_view_id',
            //'currency_id',
            //'phone_code',
            //'name_position:ntext',
            //'vat_label:ntext',
            //'create_uid',
            //'create_date',
            //'write_uid',
            //'write_date',
            //'trial434',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
