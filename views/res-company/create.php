<?php

use yii\helpers\Html;


$this->title = 'Create Res Company';
$this->params['breadcrumbs'][] = ['label' => 'Res Companies', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-company-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
