<?php

use yii\helpers\Html;


$this->title = 'Create Res Country State';
$this->params['breadcrumbs'][] = ['label' => 'Res Country States', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-country-state-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
